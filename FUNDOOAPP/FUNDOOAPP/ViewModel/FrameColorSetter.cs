﻿//-----------------------------------------------------------------------
// <copyright file="FrameColorSetter.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FUNDOOAPP.ViewModel
{
    using FUNDOOAPP.Models;
    using Xamarin.Forms;

    /// <summary>
    /// this FrameColorSetter class instance
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
   public class FrameColorSetter : ContentPage
    {
        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <param name="frame">The frame.</param>
        public static void GetColor(Note note, Frame frame)
        {
            if (note.ColorNote.Equals("Red"))
            {
                frame.BackgroundColor = Color.Red;
                return;
            }

            if (note.ColorNote.Equals("Aqua"))
            {
                frame.BackgroundColor = Color.Aqua;
                return;
            }

            if (note.ColorNote.Equals("DarkGoldenrod"))
            {
                frame.BackgroundColor = Color.DarkGoldenrod;
                return;
            }

            if (note.ColorNote.Equals("Gold"))
            {
                frame.BackgroundColor = Color.Gold;
                return;
            }

            if (note.ColorNote.Equals("GreenYellow"))
            {
                frame.BackgroundColor = Color.GreenYellow;
                return;
            }

            if (note.ColorNote.Equals("Gray"))
            {
                frame.BackgroundColor = Color.Gray;
                return;
            }

            if (note.ColorNote.Equals("Lavender"))
            {
                frame.BackgroundColor = Color.Green;
                return;
            }

            if (note.ColorNote.Equals("MintCream"))
            {
                frame.BackgroundColor = Color.MintCream;
                return;
            }

            if (note.ColorNote.Equals("White"))
            {
                frame.BackgroundColor = Color.White;
                return;
            }

            if (note.ColorNote.Equals("Green"))
            {
                frame.BackgroundColor = Color.Green;
                return;
            }

            if (note.ColorNote.Equals("Yellow"))
            {
                frame.BackgroundColor = Color.Yellow;
                return;
            }

            if (note.ColorNote.Equals("Orange"))
            {
                frame.BackgroundColor = Color.Orange;
                return;
            }

            if (note.ColorNote.Equals("Teal"))
            {
                frame.BackgroundColor = Color.Teal;
                return;
            }

            if (note.ColorNote.Equals("Purple"))
            {
                frame.BackgroundColor = Color.Purple;
                return;
            }

            if (note.ColorNote.Equals("Brown"))
            {
                frame.BackgroundColor = Color.Brown;
                return;
            }
        }

        /// <summary>
        /// Gets the color of the hexadecimal.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <returns>return task</returns>
        public static string GetHexColor(Note note)
        {
            if (note.ColorNote.Equals("Green"))
            {
                return "008000";
            }

            if (note.ColorNote.Equals("Aqua"))
            {
                return "00ffff";
            }

            if (note.ColorNote.Equals("DarkGoldenrod"))
            {
                return "b8860b";
            }

            if (note.ColorNote.Equals("Gold"))
            {
                return "ffd700";
            }

            if (note.ColorNote.Equals("GreenYellow"))
            {
                return "adff2f";
            }

            if (note.ColorNote.Equals("Gray"))
            {
                return "808080";
            }

            if (note.ColorNote.Equals("Lavender"))
            {
                return "e6e6fa";
            }

            if (note.ColorNote.Equals("MintCream"))
            {
                return "f5fffa";
            }

            return "ffffff";
        }
    }
}
