using Pilot.Migrations;
using Pilot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Pilot.Tests
{
    public class EmployeeTest
    {
        [Fact]
        public void ChangeEmployeeChanges()
        {
            //Arrange
            Employee em = new Employee 
            { 
                FirstName = "First Name Test", 
                LastName = "Last Name Test",
                Email = "Email@Test.com",
                RatePerHour = 2,
            };
            //Act
            em.FirstName = "New First Name";
            em.LastName = "New Last Name";
            em.Email = "Test@mail.com";
            em.RatePerHour = 1;
            //Assert
            Assert.Equal("New First Name", em.FirstName);
            Assert.Equal("New Last Name", em.LastName);
            Assert.Equal("Test@mail.com", em.Email);
            Assert.Equal(1, em.RatePerHour);
        }

        [Fact]
        public void CasualEmployeeChanges()
        {
            //Arrange
            CasualEmployee em = new CasualEmployee
            {
                FirstName = "First Name Test",
                LastName = "Last Name Test",
                Email = "Email@Test.com",
                Role = "Role Level 1",
                RatePerHour = 2,
            };
            //Act
            em.FirstName = "First Name Test";
            em.LastName = "Last Name Test";
            em.Email = "Test@mail.com";
            em.Role = "Role Level 2";
            em.RatePerHour = 1;
            //Assert
            Assert.Equal("First Name Test", em.FirstName);
            Assert.Equal("Last Name Test", em.LastName);
            Assert.Equal("Test@mail.com", em.Email);
            Assert.Equal("Role Level 2", em.Role);
            Assert.Equal(1, em.RatePerHour);

        }
    }
}
