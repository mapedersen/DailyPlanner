import { Badge, Button, Card, Group, Text } from "@mantine/core";
import type { Habit } from "../../types/types";

interface HabitProps {
  habit: Habit;
}

export function Habit({ habit }: HabitProps) {
  return (
    <Card shadow="sm" padding="lg" radius="md" withBorder>
      <Group justify="space-between" mt="md" mb="xs">
        <Text fw={500}>{habit.name}</Text>
        <Badge color="pink">Active</Badge>
      </Group>

      <Text size="sm" c="dimmed">
        {habit.description}
      </Text>

      <Button color="blue" fullWidth mt="md" radius="md">
        Mark as Done
      </Button>
    </Card>
  );
}
