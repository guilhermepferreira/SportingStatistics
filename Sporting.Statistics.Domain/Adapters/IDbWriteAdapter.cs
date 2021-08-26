using Sporting.Statistics.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Sporting.Statistics.Domain.Adapters
{
    public interface IDbWriteAdapter
    {
        ///<summary>
        /// Inserir seasons que faltam.
        ///</summary>
        ///<param name="season">
        /// Dados a serem inseridos.
        ///</param>
        Task InserirSeason(int season);

        ///<summary>
        /// Inserir seasons que faltam.
        ///</summary>
        ///<param name="type">
        /// Dados a serem inseridos.
        ///</param>
        Task<Guid> InserirLeagueType(string type);

        ///<summary>
        /// Inserir seasons que faltam.
        ///</summary>
        ///<param name="pais">
        /// Dados a serem inseridos.
        ///</param>
        Task<Guid> InserirPais(Country pais);

        ///<summary>
        /// Inserir seasons que faltam.
        ///</summary>
        ///<param name="cobertura">
        /// Dados a serem inseridos.
        ///</param>
        Task<Guid> InserirCoverage(Coverage cobertura);

        ///<summary>
        /// Inserir seasons que faltam.
        ///</summary>
        ///<param name="league">
        /// Dados a serem inseridos.
        ///</param>
        Task InserirLeague(League league);

        ///<summary>
        /// Inserir teams que faltam.
        ///</summary>
        ///<param name="team">
        /// Dados a serem inseridos.
        ///</param>
        Task<Guid> InserirTeam(Team team);

        ///<summary>
        /// Inserir estadio que faltam.
        ///</summary>
        ///<param name="venue">
        /// Dados a serem inseridos.
        ///</param>
        Task<Guid> InserirEstadio(Venue venue);

        ///<summary>
        /// Inserir estadio que faltam.
        ///</summary>
        ///<param name="time">
        /// Dados a serem inseridos.
        ///</param>
        ///<param name="league">
        /// Dados a serem inseridos.
        ///</param>
        ///<param name="season">
        /// Dados a serem inseridos.
        ///</param>
        Task InserirTeamLeagueSeason(Team time, League league, Season season);
    }
}
