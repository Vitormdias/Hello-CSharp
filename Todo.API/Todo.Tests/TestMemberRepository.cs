using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Todo.Data.Abstract;
using Todo.Model;

namespace Todo.Tests
{
    class TestMemberRepository : IMemberRepository
    {
        private List<Member> memberList;
        
        public TestMemberRepository(List<Member> memberList)
        {
            this.memberList = memberList;
        }

        public void Add(Member entity)
        {
            memberList.Add(entity);
        }

        public IEnumerable<Member> AllIncluding(params Expression<Func<Member, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {

        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(Member entity)
        {
            memberList.Remove(entity);
        }

        public void DeleteWhere(Expression<Func<Member, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> FindBy(Expression<Func<Member, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Member> GetAll()
        {
            return memberList;
        }

        public Member GetSingle(int id)
        {
            return memberList.Find(x => x.Id == id);
        }

        public Member GetSingle(Expression<Func<Member, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Member GetSingle(Expression<Func<Member, bool>> predicate, params Expression<Func<Member, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        public void Update(Member entity)
        {
            var index = memberList.FindIndex(x => x.Id == entity.Id);
            memberList[index] = entity;
        }
    }
}
