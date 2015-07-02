using DomainLogic.Utilities;

namespace DomainLogic.Entities {
    /// <summary>
    /// Base entity for access to database
    /// </summary>
    public abstract class BaseEntity {
        /// <summary>
        /// Id of entity
        /// </summary>
        public int Id { get; protected set; }

        /// <summary>
        /// Default
        /// </summary>
        protected BaseEntity () {
        }

        /// <summary>
        /// Contsructor with id
        /// </summary>
        /// <param name="id"></param>
        protected BaseEntity (int id) {
            Asserts.IsNotNegative (id, id.ToString ());

            Id = id;
        }
    }
}