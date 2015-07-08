//css_import ExampleBase
using System;
using System.IO;
using CSScriptLibrary;
using OpenTK;
using OpenTK.Graphics;

public class App : ExampleBase
{
	public bool Run (string path, string name)
	{
		using (var script = new AsmHelper (CSScript.Load (path, name + ".cs", false, null)))
		using (ExampleBase example = script.CreateObject ("Example") as ExampleBase)
		using (GameWindow gamewindow = new GameWindow (720, 480, GraphicsMode.Default, "Example - " + name))
		{
			Console.WriteLine ("Example {0} running", name);
			example.Init (gamewindow);
			gamewindow.Run (60.0f);
			Console.WriteLine ("Example {0} finished", name);
		}
		
		return true;
	}

	public override void PostLoad ()
	{
		Gwen.Control.ScrollControl root = new Gwen.Control.ScrollControl (canvas);
		root.Dock = Gwen.Pos.Fill;
		root.EnableScroll (false, true);
		
		foreach (string dir in Directory.GetDirectories ("."))
		{
			string fullpath = Path.Combine (Path.GetFullPath (dir), "Example.cs");
			
			if (File.Exists (fullpath))
			{
				Gwen.Control.Button btn = new Gwen.Control.Button (root);
				btn.Height = 30;
				btn.Text = Path.GetFileName (dir);
				btn.Dock = Gwen.Pos.Top;
				
				btn.Clicked += (s, e) =>
				{
					Run (fullpath, btn.Text);
				};
			}
		}
	}
	
	static public void Main (string[] args)
	{
		using (GameWindow gamewindow = new GameWindow (640, 480, GraphicsMode.Default, "Gwen Examples"))
		using (App app = new App())
		{
			app.Init (gamewindow);
			gamewindow.Run (60.0);
		}
	}
}
