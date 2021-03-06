﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LINQ_Practice.Models;
using System.Linq;

namespace LINQ_Practice
{
    [TestClass]
    public class LINQ_Practice_Any
    {
        public List<Cohort> PracticeData { get; set; }
        public CohortBuilder CohortBuilder { get; set; }

        [TestInitialize]
        public void SetUp()
        {
            CohortBuilder = new CohortBuilder();
            PracticeData = CohortBuilder.GenerateCohorts();
        }

        [TestCleanup]
        public void TearDown()
        {
            CohortBuilder = null;
            PracticeData = null;
        }


        [TestMethod]
        public void DoAnyCohortsHavePrimaryInstructorsBornIn1980s()
        {
            var doAny = PracticeData.Any(Cohort => Cohort.PrimaryInstructor.Birthday.Year >= 1980 && Cohort.PrimaryInstructor.Birthday.Year < 1990);
            Assert.IsTrue(doAny);
        }

        [TestMethod]
        public void DoAnyCohortsHaveActivePrimaryInstructors()
        {
            var doAny = PracticeData.Any(Cohort => Cohort.PrimaryInstructor.Active);
            Assert.IsTrue(doAny);
        }

        [TestMethod]
        public void DoAnyActiveCohortsHave3JuniorInstructors()
        {
            var doAny = PracticeData.Any(Cohort => Cohort.JuniorInstructors.Count() == 3);
            Assert.IsTrue(doAny);
        }

        [TestMethod]
        public void AreAnyCohortsBothFullTimeAndNotActive()
        {
            var doAny = PracticeData.Any(Cohort => Cohort.FullTime && !Cohort.Active);
            Assert.IsTrue(doAny);
        }

        [TestMethod]
        public void AreAnyStudentsInCohort3NotActiveAndBornInOctober()
        {
            var doAny = PracticeData[3].Students.Any(student => !student.Active && student.Birthday.Month == 10);  //HINT: Cohort3 is PracticeData[2]
            Assert.IsFalse(doAny);
        }

        [TestMethod]
        public void AreAnyJuniorInstructorsInCohort4NotActive()
        {
            var doAny = PracticeData[3].JuniorInstructors.Any(instructor => !instructor.Active);
            Assert.IsFalse(doAny); //<-- change true to doAny
        }
    }
}
