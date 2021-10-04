using System;
using System.Collections.Generic;

namespace TestPro.Domain.Entities
{
    public class Question : EntityBase
    {
        public string Title { get; set; }

        public string Answer_A {  get; set; }
        public string Answer_B {  get; set; }
        public string Answer_C {  get; set; }
        public string Answer_D { get; set; }

        public string RightAnswer { get; set; }
        public bool IsPassed { get; set; }

        public Test Test {  get; set; } 
        public Guid TestId {  get; set; }
    }
}
