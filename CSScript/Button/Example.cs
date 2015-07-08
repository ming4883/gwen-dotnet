//css_reference "OpenTK.dll"
//css_reference "Gwen.dll"
//css_reference "Gwen.Renderer.OpenTK.dll"

using System;

public class Example : ExampleBase
{
	public Example()
	{
	}
	
	public override void PostLoad()
	{
		{
			Gwen.Control.Button btn = new Gwen.Control.Button (canvas);
			btn.Height = 50;
			btn.Dock = Gwen.Pos.Top;
			btn.Text = "BUTTON 1";
			btn.Clicked += (s, e) =>
			{
				Console.WriteLine ("BUTTON 1 clicked");
			};
		}
		{
			Gwen.Control.Button btn = new Gwen.Control.Button (canvas);
			btn.Height = 50;
			btn.Dock = Gwen.Pos.Top;
			btn.Text = "BUTTON 2";
			btn.Clicked += (s, e) =>
			{
				Console.WriteLine ("BUTTON 2 clicked");
			};
		}
	}
}
