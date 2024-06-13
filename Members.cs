using System;
using System.Diagnostics.Metrics;
using System.Net;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Færdighedsprøveforår2024
{
	public class Members
	{
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
      

        public Members(string name,int memberId, string email, string phone, string address, int age)
        {
            Name = name;
            ID = memberId;
            Email = email;
            Phone = phone;
            Address = address;
            Age = age;
        }

        public int AgeInYears(DateTime bday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - bday.Year;
            if (bday.AddYears(age) > now)
                age--;
            return age;
        }

        private List<Members> _members = new List<Members>();

        public void CreateMember(Members member)
        {
            _members.Add(member);
        }

        public List<Members> ShowAllMembers()
        {
            return _members;
        }

        public void UpdateMember(Members member)
        {
            Members existingMember = FindMember(member.ID);
            if (existingMember != null)
            {
                existingMember.Name = member.Name;
                existingMember.Age = member.Age;
            }
        }
        private Members FindMember(int id)
        {
            return _members.Find(m => m.ID == id);
        }


        public void DeleteMember(int id)
        {
            Members member = FindMember(id);
            if (member != null)
            {
                _members.Remove(member);
            }
        }

        // Update
        public void AddDogToMember(int memberId, Dog dog)
        {
            Members member = FindMember(memberId);
            if (member != null)
            {
                member.Dogs.Add(dog);
            }
        }

        // Delete
        public void RemoveDogFromMember(int memberId, int dogId)
        {
            Members member = FindMember(memberId);
            if (member != null)
            {
                Dog dog = member.Dogs.Find(d => d.Id == dogId);
                if (dog != null)
                {
                    member.Dogs.Remove(dog);
                }
            }
        }

        public Members()
		{
		}
	}
}

