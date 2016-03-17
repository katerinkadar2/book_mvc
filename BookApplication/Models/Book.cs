using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookApplication.Models
{
    /// <summary>
    ////Книга
    /// </summary>
    public class Book
    {

        [Required(ErrorMessage = "Не указано поле номер кейса.")]
        [Key]
        [HiddenInput]
        public int Id { get; set; }

        /// <summary>Название</summary>
        [Required(ErrorMessage = "Не указано поле Название.")]
        [Display(Name = "Название")]
        [StringLength(256)]
        public string Name { get; set; }

        [Display(Name = "Год выпуска")]

        [Required(ErrorMessage = "Не указано поле Год выпуска")]
        [Range(-5000000, 2200, ErrorMessage = "Год выпуска может быть в промежутке от -5000000 до этого года")]
        /// <summary>Год выпуска</summary>
        public int PublishYear { get; set; }

        /// <summary>Автор (справочник)</summary>
        [Required(ErrorMessage = "Не указано поле Автор")]
        [StringLength(256)]
        [Display(Name = "Автор")]
        public string Author { get; set; }


    }
}