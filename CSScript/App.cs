//css_co /unsafe;
//css_reference "OpenTK.dll"
//css_reference "Gwen.dll"
//css_reference "Gwen.Renderer.OpenTK.dll"
using System;
using System.Drawing;
using System.Threading;
using OpenTK;
using OpenTK.Graphics.OpenGL;

class App : IDisposable
{
	class UI
	{
		public UI (Gwen.Control.Canvas canvas)
		{
			Gwen.Control.TabControl tab = new Gwen.Control.TabControl (canvas);
			tab.Dock = Gwen.Pos.Fill;
			tab.TabStripPosition =Gwen.Pos.Left;
			
			{
				var pageHost = tab.AddPage ("Button");
				{
					Gwen.Control.Button btn = new Gwen.Control.Button (pageHost.Page);
					btn.Height = 50;
					btn.Dock = Gwen.Pos.Top;
					btn.Text = "BUTTON 1";
					btn.Clicked += (s, e) =>
					{
						Console.WriteLine ("BUTTON 1 clicked");
					};
				}
				{
					Gwen.Control.Button btn = new Gwen.Control.Button (pageHost.Page);
					btn.Height = 50;
					btn.Dock = Gwen.Pos.Top;
					btn.Text = "BUTTON 2";
					btn.Clicked += (s, e) =>
					{
						Console.WriteLine ("BUTTON 2 clicked");
					};
				}
			}
			
			{
				var pageHost = tab.AddPage ("TextBox");
				
				Gwen.Control.TextBox tbx = new Gwen.Control.TextBox (pageHost.Page);
				tbx.Height = 50;
				tbx.Dock = Gwen.Pos.Top;
				tbx.SetText ("TEXTBOX");
			}
			
			{
				Gwen.Control.Properties pop = new Gwen.Control.Properties (canvas);
				pop.Width = 300;
				pop.Dock = Gwen.Pos.Right;
				
				{
					pop.Add ("TEXT");
				}
				{
					var c = new Gwen.Control.Property.Check (pop);
					pop.Add ("CHECK", c, "1");
				}
				{
					var c = new Gwen.Control.Property.Color (pop);
					pop.Add ("COLOR", c, "255 0 0");
				}
				{
					var c = new Gwen.Control.Property.Number(pop);
					c.SetRange(0, 1, 0.1f);
					c.SetValue(0.2f);
					pop.Add("NUMBER", c);
				}
				{
					var c = new Gwen.Control.Property.SlidingNumber(pop);
					c.SetRange(0, 2);
					c.SetValue(0.5f);
					c.NotchCount = 10;
					c.SnapToNotches = true;
					pop.Add("SLIDING", c);
				}
			}
			
		}
		
	}
	
	private Gwen.Renderer.OpenTK renderer;
	private Gwen.Skin.Base skin;
	private Gwen.Control.Canvas canvas;
	private Gwen.Input.OpenTK input;
	private UI ui;
	
	
	public App (GameWindow gamewindow)
	{
		renderer = new Gwen.Renderer.OpenTK();
		skin = new Gwen.Skin.TexturedBase (renderer, "DefaultSkin.png");
		canvas = new Gwen.Control.Canvas (skin);
		canvas.SetSize (gamewindow.Width, gamewindow.Height);
		canvas.ShouldDrawBackground = true;
		canvas.BackgroundColor = Color.FromArgb (255, 225, 225, 225);

		input = new Gwen.Input.OpenTK (gamewindow);
		input.Initialize (canvas);
		
		gamewindow.Keyboard.KeyDown += (s, e) =>
		{
			input.ProcessKeyDown (e);
		};
		gamewindow.Keyboard.KeyUp += (s, e) =>
		{
			input.ProcessKeyUp (e);
		};

		gamewindow.Mouse.ButtonDown += (s, e) =>
		{
			input.ProcessMouseMessage (e);
		};
		gamewindow.Mouse.ButtonUp += (s, e) =>
		{
			input.ProcessMouseMessage (e);
		};
		gamewindow.Mouse.Move += (s, e) =>
		{
			input.ProcessMouseMessage (e);
		};
		gamewindow.Mouse.WheelChanged += (s, e) =>
		{
			input.ProcessMouseMessage (e);
		};

		gamewindow.Load += (s, e) =>
		{
			gamewindow.VSync = VSyncMode.On;
			
			ui = new UI (canvas);
		};
		
		gamewindow.Resize += (s, e) =>
		{
			Console.WriteLine ("App Resized to {0} {1}", gamewindow.Width, gamewindow.Height);
			GL.Viewport (0, 0, gamewindow.Width, gamewindow.Height);
			GL.MatrixMode (MatrixMode.Projection);
			GL.LoadIdentity();
			GL.Ortho (0, gamewindow.Width, gamewindow.Height, 0, -1, 1);

			canvas.SetSize (gamewindow.Width, gamewindow.Height);
		};
		
		gamewindow.UpdateFrame += (s, e) =>
		{
			if (renderer.TextCacheSize > 1000)
				renderer.FlushTextCache();
		};
		
		gamewindow.RenderFrame += (s, e) =>
		{
			canvas.RenderCanvas();
			
			gamewindow.SwapBuffers();
		};
	}
	
	public void Dispose()
	{
		Console.WriteLine("App Dispose");
		
		canvas.Dispose();
		skin.Dispose();
		renderer.Dispose();
	}
	
	static public void Main (string[] args)
	{
		using (GameWindow gamewindow = new GameWindow (720, 480))
		using (App app = new App(gamewindow))
		{
			gamewindow.Run (60.0);
		}
	}
}
