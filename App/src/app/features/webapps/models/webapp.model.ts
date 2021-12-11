import { Attachment } from "./Attachment";

export class Webapp {
  id: number = 0;
  name?: string;
  description?: string;
  hostedLocationUrl?: string;
  packagedZipFileUrl?: string;
  demoUrl?: string;
  githubUrl?: string;
  attachments?: Attachment[];
  tags?: any[];
  type?: string;
  authorName?: string;
  isLocal: boolean = true;
  isActive: boolean = true;
}
