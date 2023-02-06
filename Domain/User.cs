using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        //Фио Дата рождения Страна город пол
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        /// ФИО пользователя
        /// </summary>
        public string FIO { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Страна
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Город
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Пол
        /// </summary>
        public bool IsMale { get; set; }
    }
}