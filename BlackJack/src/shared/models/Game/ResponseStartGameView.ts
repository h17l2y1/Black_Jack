import { PlayerGameView } from './PlayerGameView';

export class ResponseStartGameView {
    gameId: string;
    bots: Array<PlayerGameView>;
    user: PlayerGameView;
    cardsleft: number;
}
