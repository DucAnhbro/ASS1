
using DataAccess;

namespace Data_Layers.Repository
{
    public interface IMemberRepository : IDisposable
    {
        IEnumerable<MemberDAO> GetMembers();
        MemberDAO GetMemberByID(int memberId);
        void InsertMember(MemberDAO member);
        void DeleteMember(int memberID);
        void UpdateMember(MemberDAO member);
        void Save();
    }
}
