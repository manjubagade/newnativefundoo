﻿//-----------------------------------------------------------------------
// <copyright file="Delete.xaml.cs" company="BridgeLabz">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------
namespace FUNDOOAPP.views
{
    using FUNDOOAPP.Database;
    using FUNDOOAPP.Interfaces;
    using FUNDOOAPP.Models;
    using FUNDOOAPP.Repository;
    using FUNDOOAPP.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using static FUNDOOAPP.DataFile.Enum;

    [XamlCompilation(XamlCompilationOptions.Compile)]

    /// <summary>
    /// Initializes a new instance of the <see cref="Delete" /> class.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    public partial class Delete : ContentPage
    {
        /// <summary>
        /// The firebase
        /// </summary>
        private Firebasedata firebase = new Firebasedata();

        /// <summary>
        /// The notes repository
        /// </summary>
        NotesRepository notesRepository = new NotesRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="Delete"/> class.
        /// </summary>
        public Delete()
        {
         this.InitializeComponent();
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected async override void OnAppearing()
        {
            var uid = DependencyService.Get<IFirebaseAuthenticator>().User();
            var notes = await this.notesRepository.GetNotesAsync(uid);
            IList<Note> noteForGrid = new List<Note>();
            if (notes != null)
            {
                foreach (var item in notes)
                {
                    if (item.noteType == NoteType.isTrash)
                    {
                        noteForGrid.Add(item);
                    }
                }
            }

            this.NoteGridView(noteForGrid);
        }

        /// <summary>
        /// Notes the grid view.
        /// </summary>
        /// <param name="list">The list.</param>
        public async void NoteGridView(IList<Note> list)
        {
            try
            {
                var alllabels = await this.firebase.GetAllLabels();
                GridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(170) });
                GridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(170) });
                GridLayout.Margin = 5;
                int rowCount = 0;
                for (int row = 0; row < list.Count; row++)
                {
                    if (row % 2 == 0)
                    {
                        GridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Auto) });
                        rowCount++;
                    }
                }

                var productIndex = 0;
                var indexe = -1;

                for (int rowIndex = 0; rowIndex < rowCount; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        Note data = null;
                        indexe++;
                        if (indexe < list.Count)
                        {
                            data = list[indexe];
                        }

                        if (productIndex >= list.Count)
                        {
                            break;
                        }

                        productIndex += 1;
                        var label = new Xamarin.Forms.Label
                        {
                            Text = data.Title,
                            TextColor = Color.Black,
                            FontAttributes = FontAttributes.Bold,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Start,
                        };

                        var labelKey = new Xamarin.Forms.Label
                        {
                            Text = data.Key,
                            IsVisible = false
                        };

                        var content = new Xamarin.Forms.Label
                        {
                            Text = data.Notes,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Start,
                        };

                        StackLayout layout = new StackLayout()
                        {
                            Spacing = 2,
                            Margin = 2,
                           //// BackgroundColor = Color.White
                        };
                        var tapGestureRecognizer = new TapGestureRecognizer();
                        layout.Children.Add(labelKey);
                        layout.Children.Add(label);
                        layout.Children.Add(content);
                        layout.GestureRecognizers.Add(tapGestureRecognizer);
                        layout.Spacing = 2;
                        layout.Margin = 2;
                       //// layout.BackgroundColor = Color.White;

                        var frame = new Frame();
                        frame.BorderColor = Color.Black;
                        frame.CornerRadius = 25;
                       // FrameColorSetter.GetColor(data, frame);
                        frame.Content = layout;

                        //foreach (LabelNotes model in alllabels)
                        //{
                        //    IList<string> lists = data.LabelsList;
                        //    foreach (var labelId in lists)
                        //    {
                        //        if (model.LabelKey.Equals(labelId))
                        //        {
                        //            var labelName = new Label
                        //            {
                        //                Text = model.Label,
                        //                HorizontalOptions = LayoutOptions.Center,
                        //                VerticalOptions = LayoutOptions.Start,
                        //                FontSize = 11
                        //            };
                        //            var labelFrame = new Frame();
                        //            labelFrame.CornerRadius = 28;
                        //            labelFrame.HeightRequest = 14;
                        //            labelFrame.Content = labelName;
                        //            labelFrame.BorderColor = Color.Gray;
                        //            labelFrame.BackgroundColor = Color.FromHex(FrameColorSetter.GetHexColor(data));
                        //            layout.Children.Add(labelFrame);
                        //        }
                        //    }
                        //}

                        tapGestureRecognizer.Tapped += (object sender, EventArgs args) =>
                        {
                            StackLayout layout123 = (StackLayout)sender;
                            IList<View> item = layout123.Children;
                            Xamarin.Forms.Label KeyValue = (Xamarin.Forms.Label)item[0];
                            var Keyval = KeyValue.Text;
                            Navigation.PushAsync(new UpdateNote(Keyval));
                        };
                        GridLayout.Children.Add(frame, columnIndex, rowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }  
    }
}