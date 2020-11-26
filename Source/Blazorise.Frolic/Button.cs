﻿#region Using directives
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
#endregion

namespace Blazorise.Frolic
{
    public partial class Button : Blazorise.Button
    {
        #region Methods

        protected override void BuildRenderTree( RenderTreeBuilder builder )
        {
            if ( IsAddons || ParentIsField )
            {
                builder
                    .OpenElement( "div" )
                    .Class( "control" );
            }

            builder
                .OpenElement( Type.ToButtonTagName() )
                .Id( ElementId )
                .Type( Type.ToButtonTypeString() )
                .Class( ClassNames )
                .Style( StyleNames )
                .Disabled( Disabled )
                .AriaPressed( Active );

            if ( Type == ButtonType.Link && To != null )
            {
                builder
                    .Role( "button" )
                    .Href( To )
                    .Target( Target );
            }
            else
            {
                builder.OnClick( this, EventCallback.Factory.Create( this, ClickHandler ) );
            }

            builder.Attributes( Attributes );
            builder.ElementReferenceCapture( capturedRef => ElementRef = capturedRef );

            if ( Loading )
            {
                builder.OpenElement( "span" );

                builder
                    .Class( "spinner-border spinner-border-sm" )
                    .Role( "status" )
                    .AriaHidden( "true" );

                builder.CloseElement();
            }

            builder.Content( ChildContent );

            builder.CloseElement();

            if ( IsAddons || ParentIsField )
            {
                builder.CloseElement();
            }
        }

        #endregion
    }
}