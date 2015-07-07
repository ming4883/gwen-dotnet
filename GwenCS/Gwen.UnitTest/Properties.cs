using System;
using Gwen.Control;

namespace Gwen.UnitTest
{
    public class Properties : GUnit
    {
        public Properties(Base parent)
            : base(parent)
        {
            {
                Control.Properties props = new Control.Properties(this);
                props.ValueChanged += OnChanged;

                props.SetBounds(10, 10, 150, 300);

                {
                    {
                        Control.PropertyRow pRow = props.Add("First Name");
                    }

                    props.Add("Middle Name");
                    props.Add("Last Name");
                }
            }

            {
                Control.PropertyTree ptree = new Control.PropertyTree(this);
                ptree.SetBounds(200, 10, 250, 300);

                {
                    Control.Properties props = ptree.Add("Item One");
                    props.ValueChanged += OnChanged;

                    props.Add("Middle Name");
                    props.Add("Last Name");
                    props.Add("Four");
                }

                {
                    Control.Properties props = ptree.Add("Item Two");
                    props.ValueChanged += OnChanged;
                    
                    props.Add("More Items");
                    props.Add("Bacon", new Control.Property.Check(props), "1");
                    
                    props.Add("To Fill");
                    props.Add("Color", new Control.Property.Color(props), "255 0 0");

                    props.Add("Out");
                    Control.Property.Number num = new Control.Property.Number(props);
                    num.SetRange(0, 1, 0.1f);
                    num.SetValue(0.2f);
                    props.Add("Number", num);

                    props.Add("Here");
                    Control.Property.SlidingNumber sld = new Control.Property.SlidingNumber(props);
                    sld.SetRange(0, 2);
                    sld.SetValue(0.5f);
                    sld.NotchCount = 10;
                    sld.SnapToNotches = true;
                    props.Add("SlidingNumber", sld);
                    
                }

                ptree.ExpandAll();
            }
        }

        void OnChanged(Base control, EventArgs args)
        {
            PropertyRow row = control as PropertyRow;
            UnitPrint(String.Format("Property changed: {0}", row.Value));
        }
    }
}
