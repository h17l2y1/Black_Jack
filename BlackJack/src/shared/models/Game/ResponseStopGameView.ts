import { PlayerGameView } from './PlayerGameView';
import { ResponseWinnerGameView } from './ResponseWinnerGameView';

export class ResponseStopGameView {
    gameId: string;
    bots: Array<PlayerGameView>;
    user: PlayerGameView;
    cardsleft: number;
    winner: ResponseWinnerGameView;
}
