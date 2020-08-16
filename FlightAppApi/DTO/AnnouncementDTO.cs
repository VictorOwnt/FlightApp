using FlightAppApi.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlightAppApi.DTO
{
    public class AnnouncementDTO : AnnouncementCreateDTO
    {
        [Required]
        public int AnnouncementId { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }

        public static AnnouncementDTO FromAnnouncement(Announcement announcement)
        {
            return new AnnouncementDTO()
            {
                AnnouncementId = announcement.Id,
                TimeStamp = announcement.Timestamp,
                Title = announcement.Title,
                Content = announcement.Content,
                PassengerId = announcement.Receiver?.Id
            };
        }
    }
}
