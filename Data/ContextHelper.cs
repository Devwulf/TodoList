using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models;

namespace TodoList.Data
{
    internal static class ContextHelper
    {
        // Change entities values after input and before syncing and saving changes
        internal static void SyncEntitiesStatePreCommit(this DbContext dbContext)
        {
            foreach (var dbEntityEntry in dbContext.ChangeTracker.Entries())
            {
                // Get the ITrackable portion of our model
                var trackableObject = dbEntityEntry.Entity as ITrackable;
                if (trackableObject == null)
                    continue;

                // Cache the time now
                var dateTime = DateTime.Now;

                // Set the DateCreated only for the newly added entities
                if (dbEntityEntry.State == EntityState.Added)
                {
                    trackableObject.DateCreated = dateTime;
                    trackableObject.DateModified = dateTime;
                }
                else
                {
                    // We don't want to modify the current DateCreated
                    dbEntityEntry.Property("DateCreated").IsModified = false;
                }

                // Set the DateModified for the entities that have been changed
                if (dbEntityEntry.State == EntityState.Modified)
                {
                    trackableObject.DateModified = dateTime;
                }
            }
        }
    }
}
