using Microsoft.EntityFrameworkCore;
using ProjectoSchool_API.Models;

namespace ProjectoSchool_API.Data
{
    public class Repository : IRepository
    {
        /* Propriedade read only (somente leitura) do construtor */
        public DataContext _context { get; }

        public Repository(DataContext context)
        {
            /* O construtor recebe um DataContext que e o meu contexto */
            _context = context;
        }        

        /* Recebe uma entidade generica e adiciona no contexto */
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        /* Recebe uma entidade generica e apaga no contexto */
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        /* OBS: Se é um Task então ele gera uma thread */
        public async Task<bool> SaveChangesAsync()
        {
            /* OBS: await - vai esperar o contexto verificar se tem alguma operação(Inserção, Atualização ou Deleção)
             e se for maior que zero retorna verdadeiro ou falso */
            return (await _context.SaveChangesAsync()) > 0;
        }

        /* Recebe uma entidade generica e atualiza no contexto */
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        /* Aluno */
        public async Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if(includeProfessor)
            {
                query = query.Include(a => a.Professor);
            }

            /* AsNoTracking - usado para não travar o recurso */
            query = query
                .AsNoTracking()
                .OrderBy(a => a.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno[]> GetAlunosAsyncByProfessorId(int professorId, bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (includeProfessor)
            {
                query = query.Include(a => a.Professor);
            }

            /* AsNoTracking - usado para não travar o recurso */
            query = query
                .AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(aluno => aluno.ProfessorId == professorId);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunoAsyncById(int alunoId, bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (includeProfessor)
            {
                query = query.Include(a => a.Professor);
            }

            /* AsNoTracking - usado para não travar o recurso */
            query = query
                .AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(aluno => aluno.Id == alunoId);

            return await query.FirstOrDefaultAsync();
        }


        /* Professor */
        public async Task<Professor[]> GetAllProfessorAsync(bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAluno)
            {
                query = query.Include(p => p.Alunos);
            }

            /* AsNoTracking - usado para não travar o recurso */
            query = query
                .AsNoTracking()
                .OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Professor> GetProfessorAsyncById(int professorId, bool includeAluno = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAluno)
            {
                query = query.Include(p => p.Alunos);
            }

            /* AsNoTracking - usado para não travar o recurso */
            query = query
                .AsNoTracking()
                .OrderBy(p => p.Id)
                .Where(professor => professor.Id == professorId);

            return await query.FirstOrDefaultAsync();
        }
    }
}
