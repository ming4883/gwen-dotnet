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
		Gwen.Control.Properties pop = new Gwen.Control.Properties (canvas);
		pop.Dock = Gwen.Pos.Fill;
		pop.ValueChanged += (s, e) =>
		{
			Gwen.Control.PropertyRow row = s as Gwen.Control.PropertyRow;
            Console.WriteLine (string.Format ("Property changed: {0}", row.Value));
		};
		
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
			c.SetRange (0, 1, 0.1f);
			c.SetValue (0.2f);
			pop.Add ("NUMBER", c);
		}
		{
			var c = new Gwen.Control.Property.SlidingNumber(pop);
			c.SetRange (0, 2);
			c.SetValue (0.5f);
			c.NotchCount = 10;
			c.SnapToNotches = true;
			pop.Add ("SLIDING", c);
		}
	}
}
