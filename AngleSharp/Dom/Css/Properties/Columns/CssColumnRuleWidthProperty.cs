﻿namespace AngleSharp.Dom.Css
{
    using System;
    using AngleSharp.Css;
    using AngleSharp.Css.Values;
    using AngleSharp.Extensions;

    /// <summary>
    /// More information available at:
    /// https://developer.mozilla.org/en-US/docs/Web/CSS/column-rule-width
    /// Gets the width of the column-rule.
    /// </summary>
    sealed class CssColumnRuleWidthProperty : CssProperty
    {
        #region ctor

        internal CssColumnRuleWidthProperty(CssStyleDeclaration rule)
            : base(PropertyNames.ColumnRuleWidth, rule, PropertyFlags.Animatable)
        {
        }

        #endregion

        #region Methods

        protected override Object GetDefault(IElement element)
        {
            return Length.Medium;
        }

        protected override Object Compute(IElement element)
        {
            return Converters.LineWidthConverter.Convert(Value);
        }

        protected override Boolean IsValid(CssValue value)
        {
            return Converters.LineWidthConverter.Validate(value);
        }

        #endregion
    }
}
