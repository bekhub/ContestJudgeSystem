export interface Submission {
  languageId: number;
  sourceCode: string;
  files: {
    input: File,
    output: File,
  }[];
  checkerType: CheckerEnum;
  checker: string;
}

export interface SubmissionDetail {
  language: string;
  sourceCode: string;
  results: string[];
  result: string;
  mode: string;
}

export interface SubmissionList {
  id: number;
  language: string;
  result: string;
}

export enum CheckerEnum {
  Default=1,
  Custom=2,
}
