
import { useState } from 'react';
import TopBar from './Components/TopBar/TopBar';
import TodayPage from './pages/Today/TodayPage';
import RoutinesPage from './pages/Routines/RoutinesPage';
import './App.css';

function App() {
  const [activePage, setActivePage] = useState('today');

  return (
    <div className="app">
      <TopBar
        activePage={activePage}
        onPageChange={setActivePage}
      />

      {activePage === 'today' && <TodayPage />}
      {activePage === 'routines' && <RoutinesPage />}
    </div>
  );
}

export default App;
