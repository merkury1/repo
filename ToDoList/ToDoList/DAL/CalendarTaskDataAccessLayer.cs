using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.DAL
{
    class CalendarTaskDataAccessLayer
    {
        public List<Activity> GetByDate(String byDate)
        {
            using (var contextWrapper = new ContextWrapper())
            {
                return contextWrapper.Context.Activities.Where(x => x.Date.Contains(byDate)).OrderBy(x=>x.Date).ToList();
            }
        }

        public Activity GetByDateSingle(String byDate)
        {
            using (var contextWrapper = new ContextWrapper())
            {
                return contextWrapper.Context.Activities.Where(x => (x.Date.Contains(byDate))).FirstOrDefault();
            }
        }

        public Activity GetById(long id)
        {
            using (var contextWrapper = new ContextWrapper())
            {
                return contextWrapper.Context.Activities.Where(x => x.Id == id).SingleOrDefault();
            }
        }

        public void AddActivity(Activity activity)
        {
            using (var contextWrapper = new ContextWrapper())
            {
                contextWrapper.Context.Activities.Add(activity);
                contextWrapper.Save();
            }
        }

        public void ModifyActivity(Activity activity)
        {
            using (var contextWrapper = new ContextWrapper())
            {
                var currentActivity = contextWrapper.Context.Activities.Where(x => x.Id == activity.Id).SingleOrDefault();
                if (currentActivity == null)
                {
                    throw new Exception(String.Format("Activity with requested Id {0} is missing.", activity.Id));
                }
                currentActivity.Date = activity.Date;
                currentActivity.Action = activity.Action;
                contextWrapper.Save();
            }
        }

        public void DeleteActivity(long? id)
        {
            using (var contextWrapper = new ContextWrapper())
            {
                var currentActivity = contextWrapper.Context.Activities.Where(x => x.Id == id).SingleOrDefault();
                if (currentActivity == null)
                {
                    throw new Exception(String.Format("Activity with requested Id {0} is missing.", id));
                }
                contextWrapper.Context.Activities.Remove(currentActivity);
                contextWrapper.Save();
            }
        }
    }
}
