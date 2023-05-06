using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CommandsService.Models;

namespace CommandsService.Dtos
{
    public class CommandCreateDto
    {
        [Required]
        public string? HowTo { get; set; }
        
        [Required]
        public string? CommandLine { get; set; }
    }
}