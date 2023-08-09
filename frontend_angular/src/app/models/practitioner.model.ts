export class Practitioner {
  id: string;
  displayName: string;
  discipline: string;

  constructor(id: string, displayName: string, discipline: string) {
    this.id = id;
    this.displayName = displayName;
    this.discipline = discipline;
  }
}
