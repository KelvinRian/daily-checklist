
const API_BASE_URL = import.meta.env.VITE_API_BASE_URL ?? '';

export async function getRoutines({ page, pageSize, name, signal }) {
  const params = new URLSearchParams({
    Page: String(page),
    PageSize: String(pageSize),
  });

  if (name.trim()) {
    params.set('Name', name.trim());
  }

  const response = await fetch(
    `${API_BASE_URL}/api/routines?${params.toString()}`,
    { signal }
  );

  if (!response.ok) {
    throw new Error('Não foi possível carregar as rotinas.');
  }

  const data = await response.json();

  if (!Array.isArray(data)) {
    throw new Error('A resposta da API possui um formato inválido.');
  }

  return data;
}
