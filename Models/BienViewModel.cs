using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TripAdvisory_.Models
{
    public partial class TypeBienViewModel
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "*")]
        [MaxLength(4, ErrorMessage = "Taille maximale 4")]
        [Display(Name = "Code type bien")]
        public string code { get; set; }
        [Required(ErrorMessage = "*")]
        [MaxLength(80, ErrorMessage = "Taille maximale 80")]
        [Display(Name = "Type bien")]
        public string libelle { get; set; }
    }
    public class BienViewModel
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "*")]
        [MaxLength(4, ErrorMessage = "Taille maximale 4")]
        [Display(Name = "Code")]
        public string code { get; set; }
        [Required(ErrorMessage = "*")]
        [MaxLength(80, ErrorMessage = "Taille maximale 80")]
        [Display(Name = "Bien")]
        public string libelle { get; set; }

        [Display(Name = "Tarif")]
        public string prix_unitaire { get; set; }

        [Display(Name = "Places disponible")]
        public int nbr_places_dispo { get; set; }

        [Display(Name = "Total de places")]
        public int nbr_places_total { get; set; }
    }
}