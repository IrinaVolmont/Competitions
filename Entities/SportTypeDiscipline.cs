﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RollerSkatingCompetitions.Entities
{
    public class SportTypeDiscipline
    {
        [DisplayName("Направление")]
        public SportType SportType { get; set; }

        [DisplayName("Дисциплина")]
        public Discipline Discipline { get; set; }

    }
}
