﻿namespace AngleSharp.Css.MediaFeatures
{
    using System;
    using AngleSharp.Css.Values;
    using AngleSharp.Dom.Css;

    sealed class DeviceHeightMediaFeature : MediaFeature
    {
        #region Fields

        Length _length;

        #endregion

        #region ctor

        public DeviceHeightMediaFeature(String name)
            : base(name)
        {
        }

        #endregion

        #region Methods

        protected override Boolean TrySetDefault()
        {
            return true;
        }

        protected override Boolean TrySetCustom(ICssValue value)
        {
            return Converters.LengthConverter.TryConvert((CssValue)value, m => _length = m);
        }

        public override Boolean Validate(RenderDevice device)
        {
            var desired = _length.ToPixel();
            var available = (Single)device.DeviceHeight;

            if (IsMaximum)
                return available <= desired;
            else if (IsMinimum)
                return available >= desired;

            return desired == available;
        }

        #endregion
    }
}
