import { useEffect, useState } from "react";
import { fetchHabits } from "../services/apiService";
import { Habit } from "../types/types";

export function useHabits() {
  const [habits, setHabits] = useState<Habit[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    fetchHabits()
      .then(setHabits)
      .catch((err) => setError(err.message))
      .finally(() => setLoading(false));
  }, []);

  return { habits, loading, error };
}
