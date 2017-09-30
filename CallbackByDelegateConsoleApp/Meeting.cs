using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallbackByDelegateConsoleApp
{
    public class Meeting: IMeeting
    {
        public void ShowAgenda(string agenda)
        {
            Console.WriteLine("Agenda Details: " + agenda);
        }

        public void EmployeeAttendedMeeting(string employee)
        {
            Console.WriteLine("Employee attented meeting: " + employee);
        }

        public void EmployeeLeftMeeting(string employee)
        {
            Console.WriteLine("Employee left meeting: " + employee);
        }
    }

    public class MeetingRoom
    {
        private string message;
        public MeetingRoom(string message)
        {
            this.message = message;
        }

        public void StartMeeting(IMeeting meeting)
        {
            //It is a callback
            if (meeting != null) meeting.ShowAgenda(message);
            meeting.EmployeeAttendedMeeting("Pap Sogome");
        }
    }

    public class MeetingExecution
    {
        public void PerformingMeeting()
        {
            IMeeting meeting = new Meeting();
            MeetingRoom meetingStarted = new MeetingRoom("Announcing meeting start!");
            meetingStarted.StartMeeting(meeting);
        }
    }
}
