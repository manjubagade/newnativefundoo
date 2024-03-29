﻿//-----------------------------------------------------------------------
// <copyright file="MasterPageItem.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
//---------------------------------------------------------------------
namespace FUNDOOAPP.Models
{
    using System;

    /// <summary>
    /// this MasterPageItem instance
    /// </summary>
    public class MasterPageItem
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public string Icon
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the target.
        /// </summary>
        /// <value>
        /// The type of the target.
        /// </value>
        public Type TargetType
        {
            get;
            set;
        }
    }
}
