export interface Submission {
  languageId: number;
  sourceCode: string;
  files: {
    input: File,
    output: File,
  }[];
}
