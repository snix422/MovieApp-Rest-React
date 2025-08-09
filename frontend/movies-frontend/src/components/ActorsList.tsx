const ActorsList = ({ actors }: { actors: { firstName: string; lastName: string }[] }) => {
  return (
    <div className="actors-list">
      <h2>Lista Aktorów</h2>
      {actors && actors.length > 0 ? (
        <ul className="actor-list">
          {actors.map((actor, index) => (
            <li key={index} className="actor-item">
              <span className="actor-name">
                {actor.firstName} {actor.lastName}
              </span>
            </li>
          ))}
        </ul>
      ) : (
        <p>Brak aktorów do wyświetlenia.</p>
      )}
    </div>
  );
};

export default ActorsList;
