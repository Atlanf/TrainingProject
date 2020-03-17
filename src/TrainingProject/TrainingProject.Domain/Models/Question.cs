﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingProject.Domain.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Choice> Choices { get; set; }
        public bool MultipleAnswers { get; set; }
        public string Image { get; set; }
    }
}
