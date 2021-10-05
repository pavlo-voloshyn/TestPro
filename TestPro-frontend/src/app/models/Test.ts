export interface Test {
  id: string,
  desсription: string,
  questions: Question[]
}

interface Question {
  answers: string[],
  title: string
}
