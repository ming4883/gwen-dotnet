using System;

namespace Gwen.Control.Property
{
    /// <summary>
    /// Number property with a HorizontalSlider.
    /// </summary>
    public class SlidingNumber : Base
    {
        //protected readonly Control.CheckBox m_CheckBox;
        protected readonly Control.HorizontalSlider m_Slider;

        /// <summary>
        /// Initializes a new instance of the <see cref="Check"/> class.
        /// </summary>
        /// <param name="parent">Parent control.</param>
        public SlidingNumber(Control.Base parent)
            : base(parent)
        {
            m_Slider = new Control.HorizontalSlider(this);
            m_Slider.ValueChanged += OnValueChanged;
            m_Slider.ShouldDrawBackground = false;
            m_Slider.Dock = Pos.Fill;
        }

        /// <summary>
        /// Property value.
        /// </summary>
        public override string Value
        {
            get { return m_Slider.Value.ToString(); }
            set { SetValue(Value); }
        }

        public int NotchCount
        {
            get { return m_Slider.NotchCount; }
            set { m_Slider.NotchCount = value; }
        }

        public bool SnapToNotches
        {
            get { return m_Slider.SnapToNotches; }
            set { m_Slider.SnapToNotches = value; }
        }

        /// <summary>
        /// Sets the property value.
        /// </summary>
        /// <param name="value">Value to set.</param>
        /// <param name="fireEvents">Determines whether to fire "value changed" event.</param>
        public override void SetValue(string value, bool fireEvents = false)
        {
            float ret;
            if (float.TryParse(value, out ret))
            {
                SetValue(ret, fireEvents);
            }
        }

        public void SetValue(float value, bool fireEvents = false)
        {
            if (value != m_Slider.Value)
            {
                m_Slider.Value = value;
                if (fireEvents)
                    DoChanged();
            }
        }

        public void SetRange(float min, float max)
        {
            m_Slider.SetRange(min, max);
        }

        /// <summary>
        /// Indicates whether the property value is being edited.
        /// </summary>
        public override bool IsEditing
        {
            get { return m_Slider.HasFocus; }
        }

        /// <summary>
        /// Indicates whether the control is hovered by mouse pointer.
        /// </summary>
        public override bool IsHovered
        {
            get { return base.IsHovered || m_Slider.IsHovered; }
        }
    }
}
