using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using Firebase.Database.Query;
using FUNDOOAPP.Droid.Login;
using FUNDOOAPP.Droid.Model;
using FUNDOOAPP.Models;
using FUNDOOAPP.Repository;
using FUNDOOAPP.views.RemiderAndLocation;
using static FUNDOOAPP.DataFile.Enum;

namespace FUNDOOAPP.Droid
{
    [Activity(Label = "")]
    public class sample :Activity
    {
        FirebaseClient firebaseclint = new FirebaseClient("https://fundooapp-810e7.firebaseio.com/");
        EditText title1;
        EditText nodes;

 
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Editpage);
            string noteId = Intent.GetStringExtra("noteId");

             title1 = FindViewById<EditText>(Resource.Id.notetitle);
             nodes = FindViewById<EditText>(Resource.Id.notedata);
            //this.updatenote();
            if(noteId!=null)
            {
                LoginUser user1 = new LoginUser();
                var uid = user1.User();
                NotesRepository notesRepository = new NotesRepository();
                Note note =  await notesRepository.GetNoteByKeyAsync(noteId, uid);
                title1.Text = note.Title;
                nodes.Text = note.Notes;
                
               // Toast.MakeText(this, "notes updated", ToastLength.Short).Show();
            }

        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.file_settings)
            {
                //Toast.MakeText(this, "deleted", ToastLength.Short).Show();
                 return true;
            }
            if (item.ItemId == Resource.Id.new_game1)
            {
                this.DeleteNotes();
            }
            if(item.ItemId == Resource.Id.help)
            {
                this.PinNotes();
            }
            if(item.ItemId== Resource.Id.about_app)
            {
                this.archive();
            }
            if(item.ItemId== Resource.Id.delete)
            {
                this.trashnotes();
            }
            return base.OnOptionsItemSelected(item);
        }

        public async void DeleteNotes()
        {
            var noteId = Intent.GetStringExtra("noteId");
            MenuPage m = new MenuPage(noteId);
            NotesRepository notesRepository = new NotesRepository();

            LoginUser user1 = new LoginUser();
            var uid = user1.User();
            Note note = await notesRepository.GetNoteByKeyAsync(noteId, uid);
            m.DeleteNotes();
            Toast.MakeText(this, "deleted noted", ToastLength.Short).Show();   
        }

        public async void PinNotes()
        {
            var noteId = Intent.GetStringExtra("noteId");
            NotesRepository notesRepository = new NotesRepository();
            LoginUser user1 = new LoginUser();
            var uid = user1.User();
            Note note =await notesRepository.GetNoteByKeyAsync(noteId,uid);
            note.noteType = NoteType.ispin;
            await notesRepository.UpdateNoteAsync(note, noteId, uid);
            Toast.MakeText(this, "pin noted", ToastLength.Short).Show();
        }

        public async void trashnotes()
        {
            var noteId = Intent.GetStringExtra("noteId");
            NotesRepository notesRepository = new NotesRepository();
            LoginUser user1 = new LoginUser();
            var uid = user1.User();
            Note note = await notesRepository.GetNoteByKeyAsync(noteId, uid);
            note.noteType = NoteType.isTrash;
            await notesRepository.UpdateNoteAsync(note, noteId, uid);
            Toast.MakeText(this, "trash noted", ToastLength.Short).Show();
        }

        public async void archive()
        {
            var noteId = Intent.GetStringExtra("noteId");
            NotesRepository notesRepository = new NotesRepository();
            LoginUser user1 = new LoginUser();
            var uid = user1.User();
            Note note = await notesRepository.GetNoteByKeyAsync(noteId, uid);
            note.noteType = NoteType.isArchive;
            await notesRepository.UpdateNoteAsync(note, noteId, uid);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.popMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        //public async void updatenote()
        //{
        //    String noteId = Intent.GetStringExtra("noteId");
        //    LoginUser user1 = new LoginUser();
        //    var uid = user1.User();
        //    NotesRepository notesRepository = new NotesRepository();
        //    Note note = await notesRepository.GetNoteByKeyAsync(noteId, uid);
        //    title1.Text = note.Title;
        //    nodes.Text = note.Notes;
        //}

        public async override void OnBackPressed()
        {
            var noteId = Intent.GetStringExtra("noteId");
            NotesRepository notesRepository = new NotesRepository();
            if(noteId!=null)
            {
                LoginUser user1 = new LoginUser();
                var uid = user1.User();
                Note note = new Note()
                {
                    Title = title1.Text,
                    Notes = nodes.Text,
                };
                //note.noteType = NoteType.ispin;
              await  notesRepository.UpdateNoteAsync(note, noteId, uid);
            }
            else
            {
                Note notes = new Note()
                {
                    Title =title1.Text,
                    Notes=nodes.Text,
                };
                notesRepository.SaveNote(notes);
                Toast.MakeText(this, "Notes created", ToastLength.Short).Show();
            }
            base.OnBackPressed();
        }  
    }
}
