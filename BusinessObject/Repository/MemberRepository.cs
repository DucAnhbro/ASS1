
using BusinessObject.Entity;
using Data_Layers.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository, IDisposable
    {
        private DatabaseContext _context;

        public MemberRepository(DatabaseContext context)
        {
            this._context = context;
        }

        public void DeleteMember(int memberID)
        {
            MemberDAO member = _context.Members.Find(memberID);
            _context.Members.Remove(member);
        }

        public MemberDAO GetMemberByID(int memberId)
        {
            return this._context.Members.Find(memberId);
        }

        public IEnumerable<MemberDAO> GetMembers()
        {
            return this._context.Members.ToList();
        }

        public void InsertMember(MemberDAO member)
        {
            _context.Members.Add(member);
        }

        public void UpdateMember(MemberDAO member)
        {
            _context.Entry(member).State = EntityState.Modified;
        }

        private bool disposeds = false;

        protected virtual void Disposed(bool disposing)
        {
            if (!this.disposeds)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposeds = true;
        }

        public void Dispose()
        {
            Disposed(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
