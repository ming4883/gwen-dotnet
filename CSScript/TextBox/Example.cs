using System;

public class Example : ExampleBase
{
	public Example()
	{
	}
	
	public override void PostLoad()
	{
		Gwen.Control.TextBox tbx = new Gwen.Control.TextBox (canvas);
		tbx.Height = 50;
		tbx.Dock = Gwen.Pos.Top;
		tbx.SetText ("TEXTBOX");
		tbx.TextChanged += (s, e) =>
		{
			Console.WriteLine ("TextChanged {0}", tbx.Text);
		};
		tbx.SubmitPressed += (s, e) =>
		{
			Console.WriteLine ("SubmitPressed {0}", tbx.Text);
		};
		
	}
}
