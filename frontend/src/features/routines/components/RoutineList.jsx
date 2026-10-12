
import './RoutineList.css';

function RoutineList({
  routines,
  loading,
  error,
  page,
  onPageChange,
  onRetry,
}) {
  return (
    <>
      <div className="routine-list">
        <div className="routine-list-header">
          <span>Nome</span>
          <span className="actions-heading">Ações</span>
        </div>

        {loading && (
          <p className="list-message" role="status">
            Carregando rotinas...
          </p>
        )}

        {!loading && error && (
          <div className="list-message error-message" role="alert">
            <p>{error}</p>

            <button
              type="button"
              className="text-button"
              onClick={onRetry}
            >
              Tentar novamente
            </button>
          </div>
        )}

        {!loading && !error && routines.length === 0 && (
          <p className="list-message">
            Nenhuma rotina encontrada.
          </p>
        )}

        {!loading &&
          !error &&
          routines.map((routine) => (
            <div className="routine-row" key={routine.id}>
              <span className="routine-name">{routine.name}</span>

              <button
                type="button"
                className="delete-button"
                aria-label={`Excluir rotina ${routine.name}`}
                title="Excluir rotina"
              >
                <svg
                  viewBox="0 0 24 24"
                  fill="none"
                  stroke="currentColor"
                  strokeWidth="1.6"
                  strokeLinecap="round"
                  strokeLinejoin="round"
                  aria-hidden="true"
                >
                  <path d="M3 6h18" />
                  <path d="M8 6V4h8v2" />
                  <path d="m19 6-1 14H6L5 6" />
                  <path d="M10 10v6M14 10v6" />
                </svg>
              </button>
            </div>
          ))}
      </div>

      <div className="pagination">
        <button
          type="button"
          className="pagination-button"
          disabled={page === 1 || loading}
          onClick={() => onPageChange(page - 1)}
        >
          &larr;
          <span>Anterior</span>
        </button>

        <span className="page-indicator">
          Página {page}
        </span>

        <button
          type="button"
          className="pagination-button"
          disabled={loading || !!error || routines.length < 10}
          onClick={() => onPageChange(page + 1)}
        >
          <span>Próxima</span>
          &rarr;
        </button>
      </div>
    </>
  );
}

export default RoutineList;
