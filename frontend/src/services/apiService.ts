import { Habit } from "../types/types";

const API_URL = import.meta.env.VITE_BASE_URL;

export async function fetchHabits(): Promise<Habit[]> {
  const response = await fetch(`${API_URL}/habits`);
  if (!response.ok) throw new Error("Failed to fetch habits");
  return response.json();
}
