using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using UniversityFullstack.BL.Data;
using UniversityFullstack.BL.DTOs;
using UniversityFullstack.BL.Models;
using UniversityFullstack.BL.Repositories.Implements;
using UniversityFullstack.BL.Services.Implements;

namespace UniversityFullstack.API.Controllers
{
    //[Authorize]
    public class CoursesController : ApiController
    {
        private IMapper mapper;
        private readonly CourseService courseService = new CourseService(new CourseRepository(UniversityContext.Create()));

        public CoursesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }
        /// <summary>
        /// Obtiene los objetos del curso
        /// </summary>
        /// <returns>listado de objetos de los cursos</returns>
        /// <response code="200">Ok Duelve el listado de objetos solicitado</response>
        [HttpGet]
        [ResponseType(typeof(IEnumerable<CourseDTO>))]
        public async Task<IHttpActionResult> GetAll()
        {
            var courses = await courseService.GetAll();
            var courseDTO = courses.Select(x => mapper.Map<CourseDTO>(x));

            return Ok(courseDTO);
        }/// <summary>
         /// Obtiene un objeto por su ID
         /// </summary>
         /// <remarks>
         /// etiqueta para una descrpiciona mas compleja
         /// </remarks>
         /// <param name="id">Id del objto</param>
         /// <returns>Objeto del curso</returns>
         /// <response code="200">Ok.Devuelve al objeto solicitado</response>
         /// <response code="404">NotFound.No se ha encontrado el objeto solicitado</response>
        [HttpGet]
        [ResponseType(typeof(CourseDTO))]

        public async Task<IHttpActionResult> GetById(int id)
        {
            var course = await courseService.GetById(id);

            if (course == null)
                return NotFound();

            var courseDTO = mapper.Map<CourseDTO>(course);

            return Ok(courseDTO);
        }
        /// <summary>
        /// Se ingresa nuevo objeto para Course
        /// </summary>
        /// <param name="courseDTO"></param>
        /// <returns code="200">Ok.Creacion del nuevo objeto realizado</returns>
        /// <returns code="400">BadRequest. Error de servidor o sintaxis invalida</returns>

        [HttpPost]
        [ResponseType(typeof(CourseDTO))]
        public async Task<IHttpActionResult> Post(CourseDTO courseDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var course = mapper.Map<Course>(courseDTO);
                course = await courseService.Insert(course);
                return Ok(course);

            }
            catch (Exception ex) { return InternalServerError(ex); }
           
        }
        /// <summary>
        /// Modificacion del objeto por su ID
        /// </summary>
        /// <param name="courseDTO"></param>
        /// <param name="id"></param>
        /// <returns code="200">Ok. Actualizacion de objeto realizado con exito</returns>
        /// <returns code="404">NotFound. No se encontro el objeto a modificar</returns>
        /// <returns code="400">BadRequest. servisor no pudo interpretar o sintaxis de peticion invalida</returns>
        [HttpPut]
        [ResponseType(typeof(CourseDTO))]
        public async Task<IHttpActionResult> Put(CourseDTO courseDTO, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (courseDTO.CourseID != id)
                return BadRequest();

            var flag = await courseService.GetById(id);

            if (flag == null)
                return NotFound();

            try
            {
                var course = mapper.Map<Course>(courseDTO);
                course = await courseService.Update(course);
                return Ok(course);


            }
            catch (Exception ex) { return InternalServerError(ex); }
            }

        /// <summary>
        /// Eliminar objeto por su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns code="200">Ok. Objeto eliminado con exito</returns>
        /// <returns code="404">NotFound. No se encontro el objeto solicitado</returns>
        [HttpDelete]
        [ResponseType(typeof(CourseDTO))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await courseService.GetById(id);

            if (flag == null)
                return NotFound();

            try
            {
                if (!await courseService.DeleteCheckOnEntity(id))
                    await courseService.Delete(id);
                else
                    throw new Exception("Foreingkeys");

                return Ok();
            }
            catch (Exception ex) { return InternalServerError(ex); }
           
        }
    }

}
