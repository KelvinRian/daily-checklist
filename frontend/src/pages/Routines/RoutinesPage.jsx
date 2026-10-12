
import { useEffect, useState } from 'react';
import { getRoutines } from '../../features/routines/services/routineService';
import RoutineList from '../../features/routines/components/RoutineList';
import './RoutinesPage.css';

const PAGE_SIZE = 10;

function RoutinesPage() {
  const [routines, setRoutines] = useState([]);
  const [nameFilter, setNameFilter] = useState('');
  const [page, setPage] = useState(1);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');
  const [reloadKey, setReloadKey] = useState(0);

  useEffect(() => {
    const controller = new AbortController();

    async function loadRoutines() {
      setLoading(true);
      setError('');

      try {
        const data = await getRoutines({
          page,
          pageSize: PAGE_SIZE,
          name: nameFilter,
          signal: controller.signal,
        });

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

    loadRoutines();

    return () => controller.abort();
  }, [page, nameFilter, reloadKey]);

  function handleFilterChange(event) {
    setNameFilter(event.target.value);
    setPage(1);
  }

  function handlePageChange(newPage) {
    setPage(newPage);
  }

  function handleRetry() {
    setReloadKey((current) => current + 1);
  }

  return (
    <main className="routines-page">
      <div className="page-heading">
        <div>
          <h1>Rotinas</h1>
          <p>Gerencie suas rotinas</p>
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
            onChange={handleFilterChange}
          />
        </label>
      </div>

      <RoutineList
        routines={routines}
        loading={loading}
        error={error}
        page={page}
        onPageChange={handlePageChange}
        onRetry={handleRetry}
      />
    </main>
  );
}

export default RoutinesPage;
