using Microsoft.EntityFrameworkCore;
using Planificalo.Backend.Data;
using Planificalo.Backend.Repositories.Interfaces;
using Planificalo.Shared.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planificalo.Backend.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(DataContext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public virtual async Task<ActionResponse<T>> AddAsync(T entity)
        {
            try
            {
                ConvertDateProperties(entity);
                await _entity.AddAsync(entity);
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    Success = true,
                    CodError = string.Empty,
                    Entity = entity
                };
            }
            catch (DbUpdateException ex)
            {
                return DbUpdateExceptionActionResponse(ex);
            }
            catch (Exception ex)
            {
                return new ActionResponse<T>
                {
                    Success = false,
                    CodError = "ERR001",
                    Message = ex.Message
                };
            }
        }

        public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
        {
            try
            {
                var entity = await _entity.FindAsync(id);
                if (entity == null)
                {
                    return new ActionResponse<T>
                    {
                        Success = false,
                        CodError = "ERR002",
                        Message = "Entity not found"
                    };
                }

                _entity.Remove(entity);
                await _context.SaveChangesAsync();

                return new ActionResponse<T>
                {
                    Success = true,
                    CodError = string.Empty,
                    Entity = entity
                };
            }
            catch (DbUpdateException ex)
            {
                return DbUpdateExceptionActionResponse(ex);
            }
            catch (Exception ex)
            {
                return new ActionResponse<T>
                {
                    Success = false,
                    CodError = "ERR001",
                    Message = ex.Message
                };
            }
        }

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAllAsync()
        {
            var entities = await _entity.ToListAsync();
            return new ActionResponse<IEnumerable<T>>
            {
                Success = true,
                CodError = string.Empty,
                Entity = entities
            };
        }

        public virtual async Task<ActionResponse<T>> GetByIdAsync(int id)
        {
            try
            {
                var entity = await _entity.FindAsync(id);
                if (entity == null)
                {
                    return new ActionResponse<T>
                    {
                        Success = false,
                        CodError = "ERR002",
                        Message = "Entity not found"
                    };
                }
                return new ActionResponse<T>
                {
                    Success = true,
                    CodError = string.Empty,
                    Entity = entity
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse<T>
                {
                    Success = false,
                    CodError = "ERR001",
                    Message = ex.Message
                };
            }
        }

        public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
        {
            try
            {
                ConvertDateProperties(entity);
                _entity.Update(entity);
                await _context.SaveChangesAsync();
                return new ActionResponse<T>
                {
                    Success = true,
                    CodError = string.Empty,
                    Entity = entity
                };
            }
            catch (DbUpdateException ex)
            {
                return DbUpdateExceptionActionResponse(ex);
            }
            catch (Exception ex)
            {
                return new ActionResponse<T>
                {
                    Success = false,
                    CodError = "ERR001",
                    Message = ex.Message
                };
            }
        }

        private ActionResponse<T> DbUpdateExceptionActionResponse(Exception ex)
        {
            return new ActionResponse<T>
            {
                Success = false,
                CodError = "ERR003",
                Message = ex.Message
            };
        }

        private void ConvertDateProperties(T entity)
        {
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                {
                    var value = property.GetValue(entity);
                    if (value != null && DateTime.TryParseExact(value.ToString(), "dd-MM-yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
                    {
                        property.SetValue(entity, date);
                    }
                }
            }
        }
    }
}