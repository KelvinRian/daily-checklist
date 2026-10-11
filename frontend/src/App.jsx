
import { useEffect, useState } from 'react';
import './App.css';

const PAGE_SIZE = 10;
const API_BASE_URL = import.meta.env.VITE_API_BASE_URL ?? '';

function App() {
  const [activePage, setActivePage] = useState('today');

  const [routines, setRoutines] = useState([]);
  const [nameFilter, setNameFilter] = useState('');
  const [page, setPage] = useState(1);

  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  const [reloadKey, setReloadKey] = useState(0);

  useEffect(() => {
    if (activePage !== 'routines') {
      return;
    }

    const controller = new AbortController();

    async function fetchRoutines() {
      setLoading(true);
      setError('');

      const params = new URLSearchParams({
        Page: String(page),
        PageSize: String(PAGE_SIZE),
      });

      const name = nameFilter.trim();

      if (name) {
        params.set('Name', name);
      }

      try {
        const response = await fetch(
          `${API_BASE_URL}/api/routines?${params.toString()}`,
          { signal: controller.signal }
        );

        if (!response.ok) {
          throw new Error('Não foi possível carregar as rotinas.');
        }

        const data = await response.json();
        console.log(data)
        if (!Array.isArray(data)) {
          throw new Error('A resposta da API possui um formato inválido.');
        }

        setRoutines(data);
      } catch (err) {
        if (err.name === 'AbortError') {
          return;
        }

        setRoutines([]);
        setError(
          err.message || 'Ocorreu um erro ao carregar as rotinas.'
        );
      } finally {
        if (!controller.signal.aborted) {
          setLoading(false);
        }
      }
    }

    fetchRoutines();

    return () => controller.abort();
  }, [activePage, page, nameFilter, reloadKey]);

  function handleNameFilterChange(event) {
    setNameFilter(event.target.value);
    setPage(1);
  }

  function handlePageChange(newPage) {
    setPage(newPage);
  }

  return (
    <div className="app">
      <header className="topbar">
        <a className="brand" href="/" aria-label="Routine - início">
          <span className="brand-icon" aria-hidden="true">
            <span />
            <span />
            <span />
          </span>

          <span className="brand-name">Routine</span>
        </a>

        <nav className="navigation" aria-label="Navegação principal">
          <button
            type="button"
            className={`nav-item ${
              activePage === 'today' ? 'active' : ''
            }`}
            aria-current={activePage === 'today' ? 'page' : undefined}
            onClick={() => setActivePage('today')}
          >
            Hoje
          </button>

          <button
            type="button"
            className={`nav-item ${
              activePage === 'routines' ? 'active' : ''
            }`}
            aria-current={activePage === 'routines' ? 'page' : undefined}
            onClick={() => setActivePage('routines')}
          >
            Rotinas
          </button>
        </nav>
      </header>

      <main className="main-content">
        {activePage === 'routines' && (
          <section className="routines-page">
            <div className="page-heading">
              <div>
                <h1>Rotinas</h1>
              </div>

              <button type="button" className="primary-button">
                <span aria-hidden="true">+</span>
                Nova Rotina
              </button>
            </div>

            <div className="routine-toolbar">
              <label className="filter-field">
                <span className="filter-icon" aria-hidden="true">
                  <svg
                    viewBox="0 0 24 24"
                    fill="none"
                    stroke="currentColor"
                    strokeWidth="1.6"
                  >
                    <circle cx="10.8" cy="10.8" r="6.8" />
                    <path d="m16 16 4 4" />
                  </svg>
                </span>

                <input
                  type="search"
                  placeholder="Filtrar por nome..."
                  aria-label="Filtrar rotinas por nome"
                  value={nameFilter}
                  onChange={handleNameFilterChange}
                />
              </label>
            </div>

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
                    onClick={() => setReloadKey((current) => current + 1)}
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
                onClick={() => handlePageChange(page - 1)}
                aria-label="Página anterior"
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
                disabled={loading || routines.length < PAGE_SIZE || !!error}
                onClick={() => handlePageChange(page + 1)}
                aria-label="Próxima página"
              >
                <span>Próxima</span>
                &rarr;
              </button>
            </div>
          </section>
        )}
      </main>
    </div>
  );
}

export default App;
