using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniversalApp1.Models;

namespace UniversalApp1.Data
{
    public class TodoDatabase
    {
        readonly SQLiteAsyncConnection database;

        public TodoDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Todo>().Wait();
        }

        public Task<List<Todo>> GetNotesAsync()
        {
            //Get all notes.
            return database.Table<Todo>().ToListAsync();
        }

        public Task<Todo> GetNoteAsync(int id)
        {
            // Get a specific note.
            return database.Table<Todo>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Todo note)
        {
            if (note.ID != 0)
            {
                // Update an existing note.
                return database.UpdateAsync(note);
            }
            else
            {
                // Save a new note.
                return database.InsertAsync(note);
            }
        }
        public Task<int> DeleteNoteAsync(Todo note)
        {
            // Delete a note.
            return database.DeleteAsync(note);
        }
    }
}
