﻿using System;
using ScintillaNet.Abstractions;
using ScintillaNet.Abstractions.Collections;
using ScintillaNet.Abstractions.Enumerations;
using Color = Gdk.Color;
using ColorTranslator = ScintillaNet.Gtk.GdkUtils.ColorTranslator;
using Image = Gtk.Image;
using static ScintillaNet.Abstractions.ScintillaConstants;

namespace ScintillaNet.Gtk.Collections;

/// <summary>
/// Represents a margin marker in a <see cref="Scintilla" /> control.
/// </summary>
public class Marker : MarkerBase<Image, Color>
{
    /// <summary>
    /// Sets the marker symbol to a custom image.
    /// </summary>
    /// <param name="image">The Bitmap to use as a marker symbol.</param>
    /// <remarks>Calling this method will also update the <see cref="MarkerBase{TImage,TColor}.Symbol" /> property to <see cref="MarkerSymbol.RgbaImage" />.</remarks>
    public override unsafe void DefineRgbaImage(Image? image)
    {
        if (image == null)
        {
            return;
        }

        ScintillaApi.DirectMessage(SCI_RGBAIMAGESETWIDTH, new IntPtr(image.Allocation.Width));
        ScintillaApi.DirectMessage(SCI_RGBAIMAGESETHEIGHT, new IntPtr(image.Allocation.Width));

        var bytes = NativeImageRgbaConverter.PixBufToBytes(image);
        fixed (byte* bp = bytes)
        {
            ScintillaApi.DirectMessage(SCI_MARKERDEFINERGBAIMAGE, new IntPtr(Index), new IntPtr(bp));
        }
    }

    /// <summary>
    /// Sets the background color of the marker.
    /// </summary>
    /// <param name="color">The <see cref="Marker" /> background Color. The default is White.</param>
    /// <remarks>
    /// The background color of the whole line will be drawn in the <paramref name="color" /> specified when the marker is not visible
    /// because it is hidden by a <see cref="Margin.Mask" /> or the <see cref="Margin.Width" /> is zero.
    /// </remarks>
    /// <seealso cref="MarkerBase{TImage, TColor}.SetAlpha" />
    public override void SetBackColor(Color color)
    {
        var colorNum = ColorTranslator.ToInt(color);
        ScintillaApi.DirectMessage(SCI_MARKERSETBACK, new IntPtr(Index), new IntPtr(colorNum));
    }

    /// <summary>
    /// Sets the foreground color of the marker.
    /// </summary>
    /// <param name="color">The <see cref="Marker" /> foreground Color. The default is Black.</param>
    public override void SetForeColor(Color color)
    {
        var colorNum = ColorTranslator.ToInt(color);
        ScintillaApi.DirectMessage(SCI_MARKERSETFORE, new IntPtr(Index), new IntPtr(colorNum));
    }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Marker" /> class.
    /// </summary>
    /// <param name="scintilla">The <see cref="Scintilla" /> control that created this marker.</param>
    /// <param name="index">The index of this style within the <see cref="MarkerCollection" /> that created it.</param>
    public Marker(IScintillaApi scintilla, int index) : base(scintilla, index)
    {
    }
}