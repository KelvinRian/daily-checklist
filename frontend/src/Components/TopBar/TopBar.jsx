
import './TopBar.css';

function TopBar({ activePage, onPageChange }) {
  return (
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
          onClick={() => onPageChange('today')}
        >
          Hoje
        </button>

        <button
          type="button"
          className={`nav-item ${
            activePage === 'routines' ? 'active' : ''
          }`}
          aria-current={activePage === 'routines' ? 'page' : undefined}
          onClick={() => onPageChange('routines')}
        >
          Rotinas
        </button>
      </nav>
    </header>
  );
}

export default TopBar;
