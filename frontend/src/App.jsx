
import { useState } from 'react';
import './App.css';

function App() {
  const [activePage, setActivePage] = useState('today');

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
        {/* O conteúdo das telas será implementado futuramente. */}
      </main>
    </div>
  );
}

export default App;
