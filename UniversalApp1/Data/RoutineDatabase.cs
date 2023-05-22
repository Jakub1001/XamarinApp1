using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversalApp1.Models;

namespace UniversalApp1.Data
{
    public class RoutineDatabase
    {
        readonly SQLiteAsyncConnection rdatabase;

        public RoutineDatabase(string dbPath)
        {
            rdatabase = new SQLiteAsyncConnection(dbPath);
            rdatabase.CreateTableAsync<Routine>().Wait();
        }

        public Task<List<Routine>> GetNotesAsync()
        {
            //Get all notes.
            return rdatabase.Table<Routine>().ToListAsync();
        }

        public Task<Routine> GetNoteAsync(int id)
        {
            // Get a specific note.
            return rdatabase.Table<Routine>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveNoteAsync(Routine rnote)
        {
            if (rnote.ID != 0)
            {
                // Update an existing note.
                return rdatabase.UpdateAsync(rnote);
            }
            else
            {
                // Save a new note.
                return rdatabase.InsertAsync(rnote);
            }
        }

        public Task<int> DeleteNoteAsync(Routine rnote)
        {
            // Delete a note.
            return rdatabase.DeleteAsync(rnote);
        }
    }
}
