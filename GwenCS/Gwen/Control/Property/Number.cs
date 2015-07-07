using System;

namespace Gwen.Control.Property
{
    /// <summary>
    /// Number property.
    /// </summary>
    public class Number : Base
    {
        //protected readonly Control.CheckBox m_CheckBox;
        protected readonly Control.NumericUpDown m_NumericUpDown;

        /// <summary>
        /// Initializes a new instance of the <see cref="Check"/> class.
        /// </summary>
        /// <param name="parent">Parent control.</param>
        public Number(Control.Base parent)
            : base(parent)
        {
            m_NumericUpDown = new Control.NumericUpDown(this);
            m_NumericUpDown.ValueChanged += OnValueChanged;
            m_NumericUpDown.ShouldDrawBackground = false;
            m_NumericUpDown.Dock = Pos.Fill;
        }

        /// <summary>
        /// Property value.
        /// </summary>
        public override string Value
        {
            get { return m_NumericUpDown.Value.ToString(); }
            set { SetValue(Value); }
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
            if (value != m_NumericUpDown.Value)
            {
                m_NumericUpDown.Value = value;
                if (fireEvents)
                    DoChanged();
            }
        }

        public void SetRange(float minValue, float maxValue, float increment)
        {
            m_NumericUpDown.SetRange(minValue, maxValue, increment);
        }

        /// <summary>
        /// Indicates whether the property value is being edited.
        /// </summary>
        public override bool IsEditing
        {
            get { return m_NumericUpDown.HasFocus; }
        }

        /// <summary>
        /// Indicates whether the control is hovered by mouse pointer.
        /// </summary>
        public override bool IsHovered
        {
            get { return base.IsHovered || m_NumericUpDown.IsHovered; }
        }
    }
}
